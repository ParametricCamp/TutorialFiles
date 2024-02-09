let shapeColor = [0, 0, 0, 25];
let shapeSize = 250;
let strokeWidth = 10;
let angle = 0;
let hue = 0;
let buffer;
let prevLine = {};
let brushMode = "line";

function setup() {
  createCanvas(windowWidth, windowHeight);
  colorMode(HSB, 360, 100, 100, 100);

  buffer = createGraphics(windowWidth, windowHeight);
  buffer.background(255);
  buffer.colorMode(HSB, 360, 100, 100, 100);
}

function draw() {
  image(buffer, 0, 0);

  // Compute the coordinates of the line
  let x1 = mouseX + 0.5 * shapeSize * cos(angle);
  let y1 = mouseY + 0.5 * shapeSize * sin(angle);
  let x2 = mouseX - 0.5 * shapeSize * cos(angle);
  let y2 = mouseY - 0.5 * shapeSize * sin(angle);

  shapeColor = [hue, 100, 100, 25];
  stroke(shapeColor);
  strokeWeight(strokeWidth);
  line(x1, y1, x2, y2); 

  if (mouseIsPressed) {
    if (brushMode === "line") {
      buffer.stroke(shapeColor);
      buffer.strokeWeight(strokeWidth);
      buffer.line(x1, y1, x2, y2);
    } else if (brushMode === "quad") {
      buffer.noStroke();
      buffer.fill(shapeColor);
      buffer.quad(prevLine.x1, prevLine.y1, prevLine.x2, prevLine.y2, x2, y2, x1, y1);
    }
  }

  angle += 0.025;
  hue += 1;
  if (hue > 360) {
    hue = 0;
  }
  prevLine = {x1, y1, x2, y2};
}

function keyTyped() {
  switch (key) {
    case 'l': brushMode = "line"; break;
    case 'q': brushMode = "quad"; break;
    case 'c': buffer.background(255); break;
    case 's': saveCanvas("sketch", "png"); break;
  }
}