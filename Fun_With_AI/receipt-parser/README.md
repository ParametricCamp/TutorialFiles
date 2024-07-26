# Receipt Parser

## Instructions

Before running any scripts:
- Make sure you have Node.js installed in your system.
- Make sure to install all the modules by opening a terminal in this folder and running `npm install`
- Make sure you have an OpenAI Developer account with credits in it, and have an environment variable called `OPENAI_API_KEY` with your key: https://www.youtube.com/watch?v=DFmmiYlbgX0
  
You can run the main parser script like this:

    node parse-receipts.js

Once you have parsed them, you can convert the JSON file to CSV:

    node receipt-data-to-csv.js 1722005840252_parsed-receipts.json


