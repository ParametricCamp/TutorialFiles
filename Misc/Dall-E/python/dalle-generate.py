# This example is part of the `Fun with Dall-E` video tutorial series
# at ParametricCamp: https://www.youtube.com/playlist?list=PLx3k0RGeXZ_zs3az0Z2BnpTIPH2lxQfFX
import argparse
import base64
import os
import time

import openai

# Initiate the parser
parser = argparse.ArgumentParser()
parser.add_argument("-p", "--prompt", help="Text to image prompt:", default='an isometric view of a miniature city, tilt shift, bokeh, voxel, vray render, high detail')
parser.add_argument("-n", "--number", help="Number of images generated", default=1)
parser.add_argument("-s", "--size", help="The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024 for dall-e-2. Must be one of 1024x1024, 1792x1024, or 1024x1792 for dall-e-3 models.", default="1024x1024")
parser.add_argument("-m", "--model", help="Model generator: 'dalle-e-3' or 'dall-e-2' (default) ", default='dall-e-2')
parser.add_argument("-q", "--quality", help="Quality (only supported for 'dall-e-3'): 'standard' (default) or 'hd'", default='standard')
parser.add_argument("-S", "--style", help="The style of the generated images. Must be one of vivid or natural. Vivid causes the model to lean towards generating hyper-real and dramatic images. Natural causes the model to produce more natural, less hyper-real looking images. This param is only supported for dall-e-3.", default='natural')


# Read arguments from the command line
args = parser.parse_args()

openai.api_key = os.getenv("OPENAI_API_KEY")

res = openai.Image.create(
  prompt=args.prompt,
  n=int(args.number),
  size=args.size,
  model=args.model,
  quality=args.quality,
  style=args.style,
  response_format="b64_json"
)

for i in range(0, len(res['data'])):
    b64 = res['data'][i]['b64_json']
    filename = f'image_{int(time.time())}_{i}.png'
    print('Saving file ' + filename)
    with open(filename, 'wb') as f:
        f.write(base64.urlsafe_b64decode(b64))