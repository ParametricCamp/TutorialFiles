const endPoint = "http://localhost:11434/api/generate";
const reqBody = {
  "model": "llama3.2:latest",
  "prompt": "What is ParametricCamp?",
  "stream": false,
};

console.log("Sending request:", reqBody);

const reqParams = {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
    'Accept-Encoding': '*', 
  },
  body: JSON.stringify(reqBody)
}

// Start request
fetch(endPoint, reqParams)
  .then(res => res.json())
  .then(json => {
    console.log(json);
    console.log();

    console.log("RESPONSE: ", json.response);
    console.log();
  });

