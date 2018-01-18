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
    fill(0, 255, 0);
    rect(this.posX, this.posY, this.width, this.height);
  }

  this.hits = function(bird) {
    return !(this.posX > bird.posX + bird.size ||
    this.posX + this.width < bird.posX ||
    this.posY > bird.posY + bird.size ||
    this.posY + this.height < bird.posY);
  }
}
