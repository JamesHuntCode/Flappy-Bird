var bird;

function setup() {
  createCanvas(600, 600);
  bird = new bird(width / 2, height / 2);
}

function draw() {
  background(51);

  bird.show();
  bird.updatePos();
}

function keyPressed() {
  if (key === ' ') {
    bird.jump();
  }
}
