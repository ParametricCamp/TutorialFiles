const SNAP_DISTANCE = 20;

let alpha = 127;
let fillColor = [0, 0, 0, alpha];
let strokeColor = [0, 0, 0, 255];
let strokeW = 2;
let shapeMode = 'ellipse';
let lastClicked = {x: 0, y: 0};
let shapePoints = [];

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
        stroke(shape.strokeColor);
        strokeWeight(shape.strokeW);
        fill(shape.fillColor);
        ellipse(shape.x, shape.y, shape.w, shape.h);
        break;
      case 'rectangle':
        stroke(shape.strokeColor);
        strokeWeight(shape.strokeW);
        fill(shape.fillColor);
        rect(shape.x, shape.y, shape.w, shape.h);
        break;
      case 'line':
        noFill();
        stroke(shape.strokeColor);
        strokeWeight(shape.strokeW);
        line(shape.x1, shape.y1, shape.x2, shape.y2);
        break;
      case 'polyline':
        stroke(shape.strokeColor);
        strokeWeight(shape.strokeW);
        fill(shape.fillColor);
        beginShape();
        for (let i = 0; i < shape.vertices.length; i++) {
          vertex(shape.vertices[i].x, shape.vertices[i].y);
        }
        endShape();
        break;
    }
  }

  // Draw shapes that we are currently manipulating/creating
  if (mouseIsPressed) {
    switch (shapeMode) {
      case 'ellipse':
        stroke(strokeColor);
        strokeWeight(strokeW);
        fill(fillColor);
        ellipse(lastClicked.x, lastClicked.y, 2 * Math.abs(mouseX - lastClicked.x), 2 * Math.abs(mouseY - lastClicked.y));
        break;

      case 'rectangle':
        stroke(strokeColor);
        strokeWeight(strokeW);
        fill(fillColor);
        rect(lastClicked.x, lastClicked.y, mouseX - lastClicked.x, mouseY - lastClicked.y);
        break;

      case 'line':
        noFill();
        stroke(strokeColor);
        strokeWeight(strokeW);
        line(lastClicked.x, lastClicked.y, mouseX, mouseY);
        break;
    }
  }

  // Draw polyline?
  if (shapeMode === 'polyline') {
    stroke(strokeColor);
    strokeWeight(strokeW);
    fill(fillColor);
    beginShape();
    for (let i = 0; i < shapePoints.length; i++) {
      vertex(shapePoints[i].x, shapePoints[i].y);
    }
    vertex(mouseX, mouseY);
    endShape();
  }
}

function mousePressed() {
  // console.log("Mouse pressed at " + mouseX + ", " + mouseY);
  lastClicked.x = mouseX;
  lastClicked.y = mouseY;

  if (shapeMode === 'polyline') {
    let shouldSnap = false;
    if (shapePoints.length > 0 && 
      dist(mouseX, mouseY, shapePoints[0].x, shapePoints[0].y) < SNAP_DISTANCE) {
      shouldSnap = true;
    }

    if (shouldSnap) {
      shapePoints.push({x: shapePoints[0].x, y: shapePoints[0].y});
      addPolyToDocument();
    } else {
      shapePoints.push({x: mouseX, y: mouseY});
    }
  }
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
        fillColor: fillColor,
        strokeColor: strokeColor,
        strokeW: strokeW
      };
      break;
    case 'rectangle':
      shape = {
        type: 'rectangle',
        x: lastClicked.x,
        y: lastClicked.y,
        w: mouseX - lastClicked.x,
        h: mouseY - lastClicked.y,
        fillColor: fillColor,
        strokeColor: strokeColor,
        strokeW: strokeW
      };
      break;
    case 'line':
      shape = {
        type: 'line',
        x1: lastClicked.x,
        y1: lastClicked.y,
        x2: mouseX,
        y2: mouseY,
        strokeColor: strokeColor,
        strokeW: strokeW
      };
      break;
  }

  if (shape !== undefined) {
    doc.shapes.push(shape);
  }
}


function keyTyped() {
  // SHAPES
  if (key === 'e') {
    shapeMode = 'ellipse';
  } else if (key === 'r') {
    shapeMode = 'rectangle';
  } else if (key === 'l') {
    shapeMode = 'line';
  } else if (key === 'p') {
    shapeMode = 'polyline';
    shapePoints = [];
  }

  // SHAPE INTERACTIONS
  if (keyCode === ENTER) {
    if (shapeMode === 'polyline') {
      addPolyToDocument();
    }
  }

  // SIZE
  if (key === '+') {
    strokeW += 2;
    console.log("Shape size is now " + strokeW);
  } else if (key === '-') {
    strokeW -= 2;
    console.log("Shape size is now " + strokeW);
  }

  // COLORS
  if (key === 'R') {
    fillColor = [255, 0, 0, alpha];
  } else if (key === 'G') {
    fillColor = [0, 255, 0, alpha];
  } else if (key === 'B') {
    fillColor = [0, 0, 255, alpha];
  } else if (key === 'W') {
    fillColor = [255, 255, 255, alpha];
  } else if (key === 'K') {
    fillColor = [0, 0, 0, alpha];
  } else if (key === 'C') {
    fillColor = [0, 255, 255, alpha];
  } else if (key === 'Y') {
    fillColor = [255, 255, 0, alpha];
  } else if (key === 'M') {
    fillColor = [255, 0, 255, alpha];
  } else if (key === 'O') {
    fillColor = [255, 165, 0, alpha];
  } else if (key === 'P') {
    fillColor = [255, 192, 203, alpha];
  } else if (key === 'L') {
    fillColor = [123, 104, 238, alpha];
  }


  // SAVING
  if (key === 'f') {
    saveCanvas('drawing_' + getDateTime(), 'png');
  } else if (key === 'j') {
    saveJSON(doc, 'drawing_' + getDateTime() + '.json');
  }
}

function addPolyToDocument() {
  let shape = {
    type: 'polyline',
    vertices: shapePoints,
    fillColor: fillColor,
    strokeColor: strokeColor,
    strokeW: strokeW
  };
  doc.shapes.push(shape);
  shapePoints = [];
}

function parseFile(file) {
  // console.log(file);

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