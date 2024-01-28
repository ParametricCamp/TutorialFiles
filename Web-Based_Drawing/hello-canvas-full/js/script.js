// A callback handler: whenever the window has 
// finished loading, run whichever function is
// assigned to the event:
window.onload = drawHouse;

/**
 * A function to draw a house on the canvas.
 */
function drawHouse() {
    const canvas = document.getElementById('2d-canvas');
    const ctx = canvas.getContext('2d');

    // Background
    ctx.fillStyle = "rgb(47, 235, 239)";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    // Ground
    ctx.fillStyle = "rgb(65, 156, 20)";
    ctx.fillRect(0, 200, canvas.width, canvas.height - 200);

    // Tree
    ctx.lineWidth = 10;
    ctx.strokeStyle = "darkgoldenrod";
    ctx.beginPath();
    ctx.moveTo(475, 230);
    ctx.lineTo(475, 145);
    ctx.stroke();

    ctx.fillStyle = "seagreen";
    ctx.beginPath();
    ctx.arc(475, 145, 38, 0, 2 * Math.PI);
    ctx.fill();

    // House
    ctx.fillStyle = "#ffffff";
    ctx.fillRect(230, 130, 120, 100);

    // Door
    ctx.fillStyle = "indianred";
    ctx.fillRect(280, 190, 20, 40);
    ctx.strokeStyle = "#000000";
    ctx.lineWidth = 1;
    ctx.strokeRect(280, 190, 20, 40);

    // Roof
    ctx.fillStyle = "sandybrown";
    ctx.beginPath();
    ctx.moveTo(200, 130);
    ctx.lineTo(380, 130);
    ctx.lineTo(290, 70);
    ctx.closePath();
    ctx.fill();
    ctx.stroke();

    canvas.onmousedown = e => {
        const rect = canvas.getBoundingClientRect();
        const x = e.clientX - rect.left;
        const y = e.clientY - rect.top;
        console.log(`Mouse clicked on canvas: [${x},${y}]`);
    }
}