var bird;
var topPipes = [];
var bottomPipes = [];

function setup() {
  createCanvas(600, 600);

  bird = new bird(width / 2, height / 2);
  var xOffset = 200;
  var space = 100;

  for (let i = 0; i < 200; i++) {
    topPipes[i] = new pipe(width/2 + xOffset, -1, random(50, height / 2));
    xOffset += 200;
  }

  xOffset = 200;
  for (let i = 0; i < 200; i++) {
    bottomPipes[i] = new pipe(width/2 + xOffset, topPipes[i].height + space, height - topPipes[i].height);
    xOffset += 200;
  }

}

function draw() {
  background(51);

  bird.show();
  bird.updatePos();

  for (let i = 0; i < topPipes.length; i++) {
    topPipes[i].update();
    topPipes[i].show();

    if (topPipes[i].posX + topPipes[i].width < 0) {
      topPipes.splice(i, 1);
    }

    if (topPipes[i].hits(bird)) {
      location.reload();
    }
  }

  for (let i = 0; i < bottomPipes.length; i++) {
    bottomPipes[i].update();
    bottomPipes[i].show();

    if (bottomPipes[i].posX + bottomPipes[i].width < 0) {
      bottomPipes.splice(i, 1);
    }

    if (bottomPipes[i].hits(bird)) {
      location.reload();
    }
  }
}

function keyPressed() {
  if (key === ' ') {
    bird.jump();
  }
}
