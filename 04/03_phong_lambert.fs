<script id="shader-fs" type="x-shader/x-fragment">
	uniform highp mat3 uNormalMatrix;
	uniform highp mat4 uMVMatrix;
	uniform highp mat4 uPMatrix;

	varying highp vec3 vColor;
	varying highp vec3 vPosition;
	varying highp vec3 N;

	void main(void) {   
		highp vec3 n = uNormalMatrix * N;

        highp vec3 pointLightPosition = vec3(1.0,2.0,-1.0);
        highp vec3 pointLightDirection = normalize(vec3(pointLightPosition.xyz - vPosition.xyz));

		highp vec3 L = vec3(uPMatrix * uMVMatrix * vec4(pointLightDirection, 1.0));        

		highp float lambert = max(dot(normalize(n), normalize(L)), 0.0);
    	gl_FragColor = vec4(vColor * lambert, 1.0);
	}
</script>