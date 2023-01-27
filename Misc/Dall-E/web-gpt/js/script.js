// We can define here the behavior for the elements on the website...

// URL for POST requests
const gptEndpoint = 'https://api.openai.com/v1/completions';

// Fetch DOM elements
const reqButton = document.getElementById('button-request');
const reqStatus = document.getElementById('request-status');

// Attach click behavior to the button
reqButton.onclick = function () {
  // Give some feedback to user
  reqStatus.innerHTML = "Request started...";

  // Fetch image request data
  const key = document.getElementById('api-key').value;
  const prompt = document.getElementById('text-prompt').value;
  const radios = document.getElementsByName('text-model');
  let model;
  for (let i = 0; i < radios.length; i++) {
    if (radios[i].checked) {
      model = radios[i].value;
      break;
    }
  }
  const tokens = Number(document.getElementById('token-count').value);
  const temp = Number(document.getElementById('temperature').value);

  // We won't do error-checking here, will leave that up to the server...

  // Form the request body according to the API:
  // https://api.openai.com/v1/completions
  const reqBody = {
    model: model,
    prompt: prompt,
    max_tokens: tokens,
    temperature: temp,
    top_p: 0.5,
    stream: false,
    logprobs: null,
    // stop: "\n"  // this was returning empty completions
  };  

  // Form the data for a POST request:
  const reqParams = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${key}`,
    },
    body: JSON.stringify(reqBody)
  }

  // Use the Fetch API to do an async POST request to OpenAI:
  // https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API
  fetch(gptEndpoint, reqParams)
    .then(res => res.json())
    .then(json => addText(json, prompt))
    .catch(error => reqStatus.innerHTML = error)
}



/**
 * Add prompts + answers to the page.
 * @param {Object} jsonData The text completion API response
 * @param {String} prompt The original prompt that generated the text completion
 * @returns 
 */
function addText(jsonData, prompt) {
  console.log(jsonData);

  // Handle a possible error response from the API
  if (jsonData.error)
  {
    reqStatus.innerHTML = 'ERROR: ' + jsonData.error.message;
    return;
  }

  // Parse the response object and attach a new text field to the page.
  const container = document.getElementById('text-container');
  for (let i = 0; i < jsonData.choices.length; i++) 
  {
    // Prompt text box
    const questionDiv = document.createElement('div');
    questionDiv.className = "question";
    const questionP = document.createElement('p');
    questionP.innerHTML = prompt;
    questionDiv.appendChild(questionP);

    // Answer text box
    const textData = jsonData.choices[i].text;
    const answerDiv = document.createElement('div');
    answerDiv.className = "answer";
    const answerP = document.createElement('p');
    answerP.innerHTML = textData;
    answerDiv.appendChild(answerP);

    // Reason text box
    let reasonData;
    switch (jsonData.choices[i].finish_reason)
    {
      case "length":
        reasonData = "(Text generation stopped due to text length)"
        break;
      case "stop":
        reasonData = "(Model decided this length of an answer was sufficient)"
        break;
      default:
        reasonData = "(Text generation stopped due to unknown reasons)"
        break;
    }
    const reasonDiv = document.createElement('div');
    reasonDiv.className = "reason";
    const reasonP = document.createElement('p');
    reasonP.innerHTML = reasonData;
    reasonDiv.appendChild(reasonP);

    // Prepend them at the top of the container
    container.prepend(
      questionDiv, 
      answerDiv,
      reasonDiv  
    );
  }

  // Log some feedback
  reqStatus.innerHTML = jsonData.choices.length +' responses received for "' + prompt + '"';
}
