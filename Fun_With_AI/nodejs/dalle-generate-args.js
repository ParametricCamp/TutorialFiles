// This example is part of the `Fun with Dall-E` video tutorial series
// at ParametricCamp: https://www.youtube.com/playlist?list=PLx3k0RGeXZ_zs3az0Z2BnpTIPH2lxQfFX
const { Configuration, OpenAIApi } = require("openai");
const fs = require('fs');
const commandLineArgs = require('command-line-args');

const optionDefinitions = [
    { name: 'prompt', alias: 'p', type: String, defaultValue: "an isometric view of a miniature city, tilt shift, bokeh, voxel, vray render, high detail" },
    { name: 'number', alias: 'n', type: Number, defaultValue: 1 },
    { name: 'size', alias: 's', type: String, defaultValue: "1024x1024" },
    { name: 'model', alias: 'm', type: String, defaultValue: "dall-e-2" },
    { name: 'quality', alias: 'q', type: String, defaultValue: "standard" },
    { name: 'style', alias: 'S', type: String, defaultValue: "natural" },
];

const options = commandLineArgs(optionDefinitions);

const key = process.env.OPENAI_API_KEY;

const configuration = new Configuration({
    apiKey: key
});
const openai = new OpenAIApi(configuration);


const predict = async function () {
    const response = await openai.createImage({
        prompt: options.prompt,
        n: options.number,
        size: options.size,
        model: options.model,
        quality: options.quality,
        style: options.style,
        response_format: 'b64_json',
    });

    return response.data;
}


predict()
    .then(
        response => {
            const now = Date.now();
            for (let i = 0; i < response.data.length; i++) {
                const b64 = response.data[i]['b64_json'];
                const buffer = Buffer.from(b64, "base64");
                const filename = `image_${now}_${i}.png`;
                console.log("Writing image " + filename);
                fs.writeFileSync(filename, buffer);
            }
        }
    )

