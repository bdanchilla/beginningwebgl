function SpherePosition () {
  this.x_offset_orig = 10.0 - Math.random() * 20.0;
  this.y_offset_orig = 10.0 - Math.random() * 20.0;
  this.z_offset_orig = -25.0 + Math.random() * 12.0;

  this.x_offset = this.x_offset_orig;
  this.y_offset = this.y_offset_orig;
  this.z_offset = this.z_offset_orig;

  this.x_angle = Math.random() * 360;
  this.y_angle = Math.random() * 360;
  this.z_angle = Math.random() * 360;
  this.angle = 0.005;
  this.radius = 0.1 + Math.random()*.2;
}