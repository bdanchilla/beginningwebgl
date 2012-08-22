<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;

	varying highp vec3 vPosition;
	void main(void) {
        vPosition = aVertexPosition;
		gl_Position = vec4(vPosition.xzy, 1.0);
	}
</script>