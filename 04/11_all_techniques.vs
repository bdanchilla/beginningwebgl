<script type="x-shader/x-vertex">
	uniform mat4 uMVMatrix;
	uniform mat4 uPMatrix;

	attribute vec3 aVertexPosition;
	attribute vec4 aVertexColor;
	attribute vec3 aVertexNormal;
	attribute vec2 aVertexTexCoord;

	varying highp vec4 vColor;
	varying highp vec3 vPosition;
	varying highp vec3 N;
	varying highp vec2 vTextureCoord;
	varying highp float fog_z;

	void main(void) {
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, 1.0);
        
        vColor = aVertexColor;
        vPosition = aVertexPosition;
		vTextureCoord = aVertexTexCoord;
		N = aVertexNormal; 
		fog_z = length(gl_Position.xyz);		
	}
</script>