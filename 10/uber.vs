<script type="x-shader/x-vertex">
	uniform mat4 uMVMatrix;
	uniform mat4 uMVInverseMatrix;
	uniform mat4 uLightMVMatrix;
	uniform mat4 uShadowBiasMatrix;
	uniform mat4 uPMatrix;

	attribute vec3 aVertexPosition;
	attribute vec4 aVertexColor;
	attribute vec3 aVertexNormal;
	attribute vec2 aVertexTexCoord;

	varying highp vec4 vColor;
	varying highp vec3 vPosition;
	varying highp vec4 shadowPosition;
	varying highp vec2 vTextureCoord;
	varying highp vec3 N;
	varying highp float fog_z;

	void main(void) {
		vec4 pos = uPMatrix * uMVMatrix * vec4(aVertexPosition, 1.0);
		vec3 vertexShifted = vec3(aVertexPosition) + 0.5;	//offset

		shadowPosition = uShadowBiasMatrix * uPMatrix * uLightMVMatrix * vec4(vertexShifted, 1.0);
        vColor = aVertexColor;
     	N = aVertexNormal;
     	vTextureCoord = aVertexTexCoord;
     	fog_z = length(gl_Position.xyz);
     	vPosition = pos.xyz; 		
		gl_Position = pos;
	}
</script>