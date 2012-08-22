<script type="x-shader/x-vertex">
	attribute vec4 aVertexPosition;
	attribute vec4 aVertexVelocity;
	
	uniform mat4 uPMatrix;
	uniform mat4 uMVMatrix;
	
	varying highp float parametricTime;
	void main(void) {
		parametricTime = (aVertexPosition.w/100.0);
		
		vec3 currentPosition = vec3(								
								aVertexPosition.x + (aVertexVelocity.x * parametricTime),
								aVertexPosition.y + (aVertexVelocity.y * parametricTime),
								aVertexPosition.z + (aVertexVelocity.x * parametricTime)
								);

		currentPosition.y -= 4.9*parametricTime*parametricTime;

		gl_Position = uPMatrix * uMVMatrix * vec4(currentPosition.xyz, 1.0);
		gl_PointSize = aVertexVelocity.z;
	}
</script>