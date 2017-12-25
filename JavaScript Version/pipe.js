function pipe(x, y, h) {
  this.posX = x;
  this.posY = y;
  this.height = h;
  this.width = 75;
  this.vel = 2;

  this.update = function() {
    this.posX -= this.vel;
  }

  this.show = function() {
    rect(this.posX, this.posY, this.width, this.height);
  }
}
