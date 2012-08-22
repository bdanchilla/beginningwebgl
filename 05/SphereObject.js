SphereObject = function SphereObject (properties) {
  var radius = (properties.radius === undefined) ?  1.0 : properties.radius;
  var position = (properties.position === undefined) ? new Vector3(0.0, 0.0, 0.0) : properties.position;
  var velocity = (properties.velocity === undefined) ? new Vector3(0.0, 0.0, 0.0) : properties.velocity;
  var acceleration = (properties.acceleration === undefined) ? new Vector3(0.0, 0.0, 0.0) : properties.acceleration;

  this.radius = radius;
  this.position = position;
  this.velocity = velocity;
  this.acceleration = acceleration;
  this.vbo_index = properties.vbo_index;
}

/*SphereObject.prototype.foobar = function (context) {
  
};
*/