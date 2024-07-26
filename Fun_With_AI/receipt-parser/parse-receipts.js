// Load some node system libraries
const fs = require('fs');
const path = require('path');
const util = require('util');

// Load the OpenAI library and create a client
const OpenAI = require('openai');
const client = new OpenAI({
  apiKey: process.env['OPENAI_API_KEY']
});

// Design/engineer a prompt that asks for the relevant information
// and forces ChatGPT to format that information in a structured way.
const prompt = `You are parsing car gas receipts. You are provided the image of a receipt, and you need to extract the following information from it: date, gallons, price per gallon and total price.

You will return the extracted information in a JSON object, using the following schema:
{
  "date": (string in YYYY/MM/DD format),
  "gallons": (float),
  "price_per_gallon": (float),
  "total_price": (float)
}

Do not include markdown formatting in your response. Do not include any explanatory notes. Do not include newline character, dollar or other symbols, stick to strings and numerical notation. Make sure the JSON object is valid.
`;


const data = [];

// Execute script!
parseImagesWithChatGPT();



// PARSING FUNCTIONS
async function parseImagesWithChatGPT() {
  const files = fs.readdirSync(path.join(__dirname, 'images'));
  const filePaths = files.map((file) => path.join(__dirname, 'images', file));

  // Send each image to ChatGPT
  for (let i = 0; i < filePaths.length; i++) {
    // Convert image to base64 format
    const base64img = "data:image/jpeg;base64," + 
      fs.readFileSync(filePaths[i], {
        encoding: 'base64'
      });

    // Send the request to ChatGPT
    console.log(`Requesting image ${files[i]}`);
    const start = performance.now();
    const response = await client.chat.completions.create({
      model: "gpt-4o",
      messages: [{
        "role": "user",
        "content": [{
            "type": "text",
            "text": prompt
          },
          {
            "type": "image_url",
            "image_url": {
              "url": base64img
            }
          }
        ]
      }],
      max_tokens: 1000,
    });

    // Print the response to the console
    console.log(`Request completed in ${(performance.now() - start).toFixed(0)}ms`);
    // console.log(response);
    console.log(response.choices[0].message);

    // Parse the response and store the data
    const jsonString = response.choices[0].message.content;
    try {
      const parsedData = JSON.parse(jsonString);
      data.push({
        image: files[i],
        reqTime: new Date().toISOString(),
        ...parsedData
      });
    }
    catch (e) {
      console.error("Failed to parse JSON", e);
      console.log(jsonString);
    }
  }

  // Save the data to a local JSON file
  const now = Date.now();
  fs.writeFileSync(path.join(__dirname, `${now}_parsed-receipts.json`), JSON.stringify(data, null, 2));

  console.log(`Data saved to ${now}_parsed-receipts.json`);
}