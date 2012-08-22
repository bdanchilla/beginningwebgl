<script type="x-shader/x-vertex">
	varying highp vec2 vTextureCoord;

	void main(void) {
		gl_Position = projectionMatrix * modelViewMatrix * vec4(position, 1.0);
        vTextureCoord = uv;
	}
</script>
