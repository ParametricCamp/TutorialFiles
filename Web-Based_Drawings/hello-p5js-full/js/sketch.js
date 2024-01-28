function setup() {
    createCanvas(600, 300);
}

function draw() {
    // Background
    background(47, 235, 239);

    // Ground
    noStroke();
    fill(65, 156, 20);
    rect(0, 200, width, height - 200);

    // Tree
    strokeWeight(10);
    stroke("darkgoldenrod");
    strokeCap('square');
    line(475, 230, 475, 145);

    noStroke();
    fill("seagreen");
    circle(475, 145, 76);

    // House
    fill(255);
    rect(230, 130, 120, 100);

    // Door
    fill("indianred");
    stroke(0);
    strokeWeight(1);
    rect(280, 190, 20, 40);

    // Roof
    fill("sandybrown");
    // triangle(200, 130, 380, 130, 290, 70);
    beginShape();
    vertex(200, 130);
    vertex(380, 130);
    vertex(290, 70);
    endShape(CLOSE);
}

function mousePressed() {
    // console.log("Mouse was clicked");
    console.log(`Mouse was clicked on: ${Math.round(mouseX)},${Math.round(mouseY)}`);
}