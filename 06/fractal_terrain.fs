<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec3 position;
	
	void main(void) {   		
		gl_FragColor = vec4(position.y*.025, .1+position.y*.25,position.y*.025, 1.0);
	}
</script>