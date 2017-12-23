function bird(x, y) {
  this.posX = x;
  this.posY = y;
  this.size = 20;
  this.vel = 0;
  this.gravity = 1;
  this.upthrust = 20;

  this.updatePos = function() {
    this.vel += this.gravity;
    this.vel *= 0.9;
    this.posY += this.vel;

    if (this.posY + this.size / 2 > height) {
      this.posY = height - this.size / 2;
      this.vel = 0;
    }
  }

  this.jump = function() {
    this.vel += -this.upthrust;
  }

  this.show = function() {
    ellipse(this.posX, this.posY, this.size, this.size);
  }
}
