WallObject = function WallObject (properties) {
  var start_x = (properties.start_x === undefined) ?  0.0 : properties.start_x;
  var start_y = (properties.start_y === undefined) ?  0.0 : properties.start_y;

  var end_x = (properties.end_x === undefined) ?  0.0 : properties.end_x;
  var end_y = (properties.end_y === undefined) ?  0.0 : properties.end_y;

  this.slope = 0.0;
  if( (end_x - start_x) > 0.0001 || (end_x - start_x) < -0.001){
  	this.slope = (end_y - start_y)/(end_x - start_x);
  }
  this.start_x = start_x;
  this.start_y = start_y;
  this.end_x = end_x;
  this.end_y = end_y;  

  var a = [start_x - end_x, start_y - end_y];
  this.angle = 0.0;
  this.angle = Math.atan2( a[1], a[0]);
}  
