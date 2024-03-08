let alpha = 127;
let shapeColor = [0, 0, 0, alpha];
let shapeMode = 'ellipse';
let shapeSize = 50;
let lastClicked = {x: 0, y: 0};

let doc = {
  backgroundColor: [255, 255, 255],
  shapes: [],
};


function setup() {
  const canvas = createCanvas(windowWidth, windowHeight);
  canvas.drop(parseFile);
}


function draw() {
  background(doc.backgroundColor);

  // Draw shapes from the doc
  for (let i = 0; i < doc.shapes.length; i++) {
    const shape = doc.shapes[i];
    switch(shape.type) {
      case 'ellipse':
        noStroke();
        fill(shape.fillColor);
        ellipse(shape.x, shape.y, shape.w, shape.h);
        break;
      case 'rectangle':
        noStroke();
        fill(shape.fillColor);
        rect(shape.x, shape.y, shape.w, shape.h);
        break;
      case 'line':
        noFill();
        stroke(shape.strokeColor);
        strokeWeight(shape.strokeWeight);
        line(shape.x1, shape.y1, shape.x2, shape.y2);
        break;
    }
  }

  // Draw shapes continuously
  if (mouseIsPressed) {
    switch (shapeMode) {
      case 'ellipse':
        noStroke();
        fill(shapeColor);
        ellipse(lastClicked.x, lastClicked.y, 2 * Math.abs(mouseX - lastClicked.x), 2 * Math.abs(mouseY - lastClicked.y));
        break;

      case 'rectangle':
        noStroke();
        fill(shapeColor);
        rect(lastClicked.x, lastClicked.y, mouseX - lastClicked.x, mouseY - lastClicked.y);
        break;

      case 'line':
        stroke(shapeColor);
        strokeWeight(shapeSize);
        line(lastClicked.x, lastClicked.y, mouseX, mouseY);
        break;
    }
  }
}

function mousePressed() {
  // console.log("Mouse pressed at " + mouseX + ", " + mouseY);
  lastClicked.x = mouseX;
  lastClicked.y = mouseY;
}

function mouseReleased() {
  let shape;
  switch(shapeMode) {
    case 'ellipse':
      shape = {
        type: 'ellipse',
        x: lastClicked.x,
        y: lastClicked.y,
        w: 2 * (mouseX - lastClicked.x),
        h: 2 * (mouseY - lastClicked.y),
        fillColor: shapeColor
      };
      break;
    case 'rectangle':
      shape = {
        type: 'rectangle',
        x: lastClicked.x,
        y: lastClicked.y,
        w: mouseX - lastClicked.x,
        h: mouseY - lastClicked.y,
        fillColor: shapeColor
      };
      break;
    case 'line':
      shape = {
        type: 'line',
        x1: lastClicked.x,
        y1: lastClicked.y,
        x2: mouseX,
        y2: mouseY,
        strokeColor: shapeColor,
        strokeWeight: shapeSize
      };
      break;
  }

  doc.shapes.push(shape);
}


function keyTyped() {
  // SHAPES
  if (key === 'e') {
    shapeMode = 'ellipse';
  } else if (key === 'r') {
    shapeMode = 'rectangle';
  } else if (key === 'l') {
    shapeMode = 'line';
  }

  // SIZE
  if (key === '+') {
    shapeSize += 10;
    console.log("Shape size is now " + shapeSize);
  } else if (key === '-') {
    shapeSize -= 10;
    console.log("Shape size is now " + shapeSize);
  }

  // COLORS
  if (key === 'R') {
    shapeColor = [255, 0, 0, alpha];
  } else if (key === 'G') {
    shapeColor = [0, 255, 0, alpha];
  } else if (key === 'B') {
    shapeColor = [0, 0, 255, alpha];
  } else if (key === 'W') {
    shapeColor = [255, 255, 255, alpha];
  } else if (key === 'K') {
    shapeColor = [0, 0, 0, alpha];
  } else if (key === 'C') {
    shapeColor = [0, 255, 255, alpha];
  } else if (key === 'Y') {
    shapeColor = [255, 255, 0, alpha];
  } else if (key === 'M') {
    shapeColor = [255, 0, 255, alpha];
  } else if (key === 'O') {
    shapeColor = [255, 165, 0, alpha];
  } else if (key === 'P') {
    shapeColor = [255, 192, 203, alpha];
  } else if (key === 'L') {
    shapeColor = [123, 104, 238, alpha];
  }

  // SAVING
  if (key === 'f') {
    saveCanvas('drawing_' + getDateTime(), 'png');
  } else if (key === 'j') {
    saveJSON(doc, 'drawing_' + getDateTime() + '.json');
  }
}


function parseFile(file) {
  console.log(file);

  if (file.subtype === 'json') {
    doc = file.data;
  }
}




// A function that returns the date and time in YYYYMMDD_HHMMSS format, with leading zeros if necessary.
function getDateTime() {
  let date = new Date();
  let year = date.getFullYear();
  let month = (date.getMonth() + 1).toString().padStart(2, '0');
  let day = date.getDate().toString().padStart(2, '0');
  let hours = date.getHours().toString().padStart(2, '0');
  let minutes = date.getMinutes().toString().padStart(2, '0');
  let seconds = date.getSeconds().toString().padStart(2, '0');
  return year + month + day + '_' + hours + minutes + seconds;
}