let buffer;
let alpha = 127;
let shapeColor = [0, 0, 0, alpha];
let shapeMode = 'circle';
let shapeSize = 50;

let lastClicked = {
  x: 0,
  y: 0
};


function setup() {
  createCanvas(windowWidth, windowHeight);

  buffer = createGraphics(windowWidth, windowHeight);
  buffer.background(255);
}

function draw() {
  image(buffer, 0, 0);

  // Draw shapes continuously
  if (mouseIsPressed) {
    noStroke();
    fill(shapeColor);

    if (shapeMode === 'circle') {
      ellipse(lastClicked.x, lastClicked.y,  2 * (mouseX - lastClicked.x),
        2 * (mouseY - lastClicked.y));
    } else if (shapeMode === 'square') {
      rect(lastClicked.x, lastClicked.y,
        mouseX - lastClicked.x,
        mouseY - lastClicked.y);
    } else if (shapeMode === 'delete') {
      buffer.noStroke();
      buffer.fill(255);
      buffer.circle(mouseX, mouseY, shapeSize);
    } else if (shapeMode === 'line') {
      stroke(shapeColor);
      strokeWeight(shapeSize);
      line(lastClicked.x, lastClicked.y, mouseX, mouseY);
    }
  }
}

function mousePressed() {
  // console.log("Mouse pressed at " + mouseX + ", " + mouseY);
  lastClicked.x = mouseX;
  lastClicked.y = mouseY;
}

function mouseReleased() {
  // console.log("mouse was previously clicked on " + lastClicked.x + ", " + lastClicked.y);
  // console.log("Mouse released at " + mouseX + ", " + mouseY);


  buffer.noStroke();
  buffer.fill(shapeColor);
  if (shapeMode === 'circle') {
    buffer.ellipse(lastClicked.x, lastClicked.y,  2 * (mouseX - lastClicked.x),
    2 * (mouseY - lastClicked.y));
  } else if (shapeMode === 'square') {
    buffer.rect(lastClicked.x, lastClicked.y,
      mouseX - lastClicked.x,
      mouseY - lastClicked.y);
  } else if (shapeMode === 'line') {
    buffer.stroke(shapeColor);
    buffer.strokeWeight(shapeSize);
    buffer.line(lastClicked.x, lastClicked.y, mouseX, mouseY);
  }

}


function keyTyped() {
  // SHAPES
  if (key === 'c') {
    shapeMode = 'circle';
  } else if (key === 's') {
    shapeMode = 'square';
  } else if (key === 'd') {
    shapeMode = 'delete';
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
    // } else if (key === 'W') {
    //   shapeColor = [255, 255, 255, 24];
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








// // Draw shapes only once!
// function mousePressed() {
//   noStroke();
//   fill(255, 0, 0, 24);
//   circle(mouseX, mouseY, 50);
// }