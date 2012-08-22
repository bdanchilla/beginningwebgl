Vector3 = function ( x, y, z ) {
	this.x = x || 0;
	this.y = y || 0;
	this.z = z || 0;
};

Vector3.prototype = {

	constructor: Vector3,

	divide: function ( s ) {
		if ( s ) {
			this.x /= s;
			this.y /= s;
			this.z /= s;
		} else {
			this.x = 0;
			this.y = 0;
			this.z = 0;
		}
		return this;
	},

	cross: function ( v ) {
		var x = this.x, y = this.y, z = this.z;
		if ( v instanceof Vector3 ) {			
			this.x = y * v.z - z * v.y;
			this.y = z * v.x - x * v.z;
			this.z = x * v.y - y * v.x;
		} 
		return this;
	},

	length: function () {
		return Math.sqrt( this.x * this.x + this.y * this.y + this.z * this.z );
	},

	normalize: function () {
		var length = this.length();		
		return this.divide( length );
	},
};
