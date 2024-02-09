
let shapeColor = [0, 0, 0, 255];
let shapeMode = 'circle';
let shapeSize = 50;

function setup() {
  createCanvas(windowWidth, windowHeight);
  rectMode(CENTER);
}

function draw() {
  // Draw shapes continuously
  if (mouseIsPressed) {
    noStroke();
    fill(shapeColor);
    
    if (shapeMode === 'circle') {
      circle(mouseX, mouseY, shapeSize);
    } else if (shapeMode === 'square') {
      square(mouseX, mouseY, shapeSize);
    } else if (shapeMode === 'delete') {
      fill(255);
      circle(mouseX, mouseY, shapeSize);
    }
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
    shapeColor = [255, 0, 0, 24];
  } else if (key === 'G') {
    shapeColor = [0, 255, 0, 24];
  } else if (key === 'B') {
    shapeColor = [0, 0, 255, 24];
  // } else if (key === 'W') {
  //   shapeColor = [255, 255, 255, 24];
  } else if (key === 'K') {
    shapeColor = [0, 0, 0, 24];
  } else if (key === 'C') {
    shapeColor = [0, 255, 255, 24];
  } else if (key === 'Y') {
    shapeColor = [255, 255, 0, 24];
  } else if (key === 'M') {
    shapeColor = [255, 0, 255, 24];
  } else if (key === 'O') {
    shapeColor = [255, 165, 0, 24];
  } else if (key === 'P') {
    shapeColor = [255, 192, 203, 24];
  } else if (key === 'L') {
    shapeColor = [123, 104, 238, 24];
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
