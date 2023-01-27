
const dalleEndpoint = 'https://api.openai.com/v1/images/generations';
const reqButton = document.getElementById('button-request');
const imgContainer = document.getElementById('image-container');
const reqStatus = document.getElementById('request-status');

reqButton.onclick = function() {
    reqButton.disabled = true;
    reqStatus.innerHTML = "Performing request...";
    
    const key = document.getElementById('api-key').value;
    const prompt = document.getElementById('text-prompt').value;
    const count = Number(document.getElementById('image-count').value);
    const radios = document.getElementsByName('image-size');
    let size;
    for (let i = 0; i < radios.length; i++)
    {
        if (radios[i].checked) 
        {
            size = Number(radios[i].value);
            break;
        }
    }

    const reqBody = {
        prompt: prompt,
        n: count,
        size: size + "x" + size,
        response_format: "url"
    }
    // console.log(reqBody);

    const reqParams = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${key}`,
        },
        body: JSON.stringify(reqBody)
    }

    fetch(dalleEndpoint, reqParams)
        .then(res => res.json())
        // .then(json => console.log(json))
        .then(addImages)
        .catch(error => {
            reqStatus.innerHTML = error;
            reqButton.disabled = false;
        });

}

function addImages(jsonData)
{
    reqButton.disabled = false;
    
    if (jsonData.error)
    {
        reqStatus.innerHTML = 'ERROR: ' + jsonData.error.message;
        return;
    }

    reqStatus.innerHTML = "Successfully retrieved " + jsonData.data.length + " images!";

    for (let i = 0; i < jsonData.data.length; i++)
    {
        const imgURL = jsonData.data[i].url;
        const imgNode = document.createElement('img');
        imgNode.src = imgURL;

        imgContainer.prepend(imgNode);        
    }
}