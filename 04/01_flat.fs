<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec3 vColor;
	varying highp vec3 N;
	varying highp vec3 L;

	void main(void) {   
		highp float lambert = max(dot(normalize(N), normalize(L)), 0.0);
    	gl_FragColor = vec4(vColor * lambert, 1.0);
	}
</script>