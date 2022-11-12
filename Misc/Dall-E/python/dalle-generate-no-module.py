# This example is part of the `Fun with Dall-E` video tutorial series
# at ParametricCamp: https://www.youtube.com/playlist?list=PLx3k0RGeXZ_zs3az0Z2BnpTIPH2lxQfFX
import os
import requests
import json
import base64, time
import argparse

# Initiate the parser
parser = argparse.ArgumentParser()
parser.add_argument("-p", "--prompt", help="Text to image prompt:", default='an isometric view of a miniature city, tilt shift, bokeh, voxel, vray render, high detail')
parser.add_argument("-n", "--number", help="Number of images generated", default=1)
parser.add_argument("-s", "--size", help="Image size: 256, 512 or 1024", default=256)

# Read arguments from the command line
args = parser.parse_args()

api_key = os.getenv("OPENAI_API_KEY")
url = 'https://api.openai.com/v1/images/generations'

custom_headers = {
    "Content-Type": "application/json",
    "Authorization": "Bearer " + api_key,
}

reqBody = {
    "prompt": args.prompt,
    "n": int(args.number),
    "size": f'{args.size}x{args.size}',
    "response_format": "b64_json"
}

res = requests.post(url, 
    data=json.dumps(reqBody),
    headers=custom_headers,
)

# print(r)
# print(r.url)
# print(r.status_code)
print(res.text)
# print(r.content)

res_json = json.loads(res.text)
for i in range(0, len(res_json['data'])):
    img_file_name = f'image_{int(time.time())}_{i}.png'
    with open(img_file_name, 'wb') as f:
        f.write(base64.urlsafe_b64decode(res_json['data'][i]['b64_json']))