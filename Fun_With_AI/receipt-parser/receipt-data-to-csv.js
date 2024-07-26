const fs = require('fs');
const path = require('path');
var util = require('util');
const csv = require('fast-csv');

/** 
 * This script is going to read a JSON file with an array of objects
 * and write it to a CSV file.
 * The input JSON looks like this:
 * [
        {
            "image": (string),
            "reqTime": (string),
            "date": (string),
            "gallons": (float),
            "price_per_gallon": (float),
            "total_price": (float),
        },
        ...
        ] 
* The output CSV should have the following columns:
* image, reqTime, date, gallons, price_per_gallon, total_price
* 
* The filename will be the first argument in the command line.
*/

// Check if the filename is provided
if (process.argv.length < 3) {
    console.log('Please provide the filename as an argument.');
    process.exit(1);
}

// Read the JSON file
const filename = process.argv[2];
const data = JSON.parse(fs.readFileSync
    (path.join(__dirname, filename), 'utf8'));


// Export CSV
const csv_file = filename.replace('.json', '.csv');
const csvStream = csv.format({ headers: true });
const fileStream = fs.createWriteStream(csv_file, { encoding: 'utf-8' });

csvStream.pipe(fileStream)
    .on('end', () => {
        console.log(`CSV file has been written to ${csv_file}`);    
        process.exit()
    });

data.forEach((item) => {
    csvStream.write(item);
});
csvStream.end();