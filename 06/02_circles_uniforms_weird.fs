<script id="shader-fs" type="x-shader/x-fragment">
	uniform sampler2D sColors;
	varying highp vec2 position;

	void main(void) {   
		highp float t = length(position);
		highp float x = sin(-position.y)*tan(length(position.xx));
		t = t+x;
		gl_FragColor = mix(vec4(0.0,0.0,0.0,1.0), vec4(texture2D(sColors, vec2(0.0, t)).rgb, 1.0), t);
	}
</script>