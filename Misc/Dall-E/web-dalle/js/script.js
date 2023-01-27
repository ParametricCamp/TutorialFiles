// We can define here the behavior for the elements on the website...

// URL for POST requests
const dalleEndpoint = 'https://api.openai.com/v1/images/generations';

// Fetch DOM elements
const reqButton = document.getElementById('button-request');
const reqStatus = document.getElementById('request-status');

// Attach click behavior to the button
reqButton.onclick = function () {

  reqButton.disabled = true; 

  // Give some feedback to user
  reqStatus.innerHTML = "Request started...";

  // Fetch image request data
  const key = document.getElementById('api-key').value;
  const prompt = document.getElementById('text-prompt').value;
  const count = Number(document.getElementById('image-count').value);
  const radios = document.getElementsByName('image-size');
  let size;
  for (let i = 0; i < radios.length; i++) {
    if (radios[i].checked) {
      size = Number(radios[i].value);
      break;
    }
  }

  // These can be handled by the server
  // // Some validity checks.
  // if (key.length == 0)
  // {
  //   reqStatus.innerHTML = "Please provide an API key!";
  //   return;
  // }
  // if (prompt.length == 0)
  // {
  //   reqStatus.innerHTML = "Please provide a text prompt!";
  //   return;
  // }
  // if (Number.isNaN(count))
  // {
  //   reqStatus.innerHTML = "Image count must be a valid number!";
  //   return;
  // }
  // if (!Number.isInteger(count))
  // {
  //   reqStatus.innerHTML = "Image count must be an integer!";
  //   return;
  // }
  // if (count < 1 || count > 4)
  // {
  //   reqStatus.innerHTML = "Image count must be between 1-4!";
  //   return;
  // }

  // Form the request body according to the API:
  // https://beta.openai.com/docs/api-reference/images/create
  const reqBody = {
    prompt: prompt,
    n: count,
    size: size + "x" + size,
    response_format: 'url',
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
  fetch(dalleEndpoint, reqParams)
    .then(res => res.json())
    .then(json => addImages(json, prompt))
    .catch(error => {
        reqStatus.innerHTML = error;
        reqButton.disabled = false;
    });
}



/**
 * Adds images on the page 
 * @param {Obj} jsonData The Dall-E API response
 * @param {String} prompt The original prompt that generated the images
 */
function addImages(jsonData, prompt) {
    
  // console.log(jsonData);
  reqButton.disabled = false;

  // Handle a possible error response from the API
  if (jsonData.error)
  {
    reqStatus.innerHTML = 'ERROR: ' + jsonData.error.message;
    return;
  }
  
  // Parse the response object, deserialize the image data, 
  // and attach new images to the page.
  const container = document.getElementById('image-container');
  for (let i = 0; i < jsonData.data.length; i++) {
    let imgData = jsonData.data[i];
    let img = document.createElement('img');
    img.src = imgData.url;
    img.alt = prompt;
    container.prepend(img);
  }

  reqStatus.innerHTML = jsonData.data.length +' images received for "' + prompt + '"';
}