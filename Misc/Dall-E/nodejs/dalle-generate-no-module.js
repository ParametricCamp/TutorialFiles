const fs = require('fs');
const commandLineArgs = require('command-line-args');

const optionDefinitions = [
    { name: 'prompt', alias: 'p', type: String, defaultValue: "an isometric view of a miniature city, tilt shift, bokeh, voxel, vray render, high detail" },
    { name: 'number', alias: 'n', type: Number, defaultValue: 1 },
    { name: 'size', alias: 's', type: Number, defaultValue: 256 },
];

const options = commandLineArgs(optionDefinitions);

const key = process.env.OPENAI_API_KEY;
const dalleEndpoint = 'https://api.openai.com/v1/images/generations';

const reqBody = {
    prompt: options.prompt,
    n: options.number,
    size: `${options.size}x${options.size}`,
    response_format: 'b64_json',
};

const reqParams = {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${key}`,
    },
    body: JSON.stringify(reqBody)
}

// Start request/s.
// You will need Node v18.X.X to use the `fetch` command in Node.js
fetch(dalleEndpoint, reqParams)
    .then(res => res.json())
    .then(saveImages);


function saveImages(jsonData)
{
    const now = Date.now();
    for (let i = 0; i < jsonData.data.length; i++) {
        const b64 = jsonData.data[i].b64_json;
        const buffer = Buffer.from(b64, "base64");
        const filename = `image_${now}_${i}.png`;
        console.log("Writing image " + filename);
        fs.writeFileSync(filename, buffer);
    }
}
