<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec2 position;
	uniform sampler2D uSampler;
	uniform int uEffect;
	
	void main(void) {
		//convert texture coordinates from [-1, 1] to [0, 1]
		highp vec2 texCoords = position * 0.5 + .5;

		highp vec4 texColor = texture2D( uSampler, vec2(texCoords.s, texCoords.t) );
		highp vec3 finalColor;

		highp float gray = texColor.r * .3 +  texColor.g * .59 + texColor.b * .11;				   
		highp float factor = 1.0;
		finalColor = vec3(gray*factor,gray*factor,gray*factor);		

		if( texColor.r > 0.2 &amp;&amp; texColor.g &lt; 0.3 &amp;&amp; texColor.b &lt; 0.3 )
		{
			finalColor = texColor.rgb;		
		}

		if( uEffect == 0 )
		{
			finalColor = texColor.rgb;
		}				   

	   gl_FragColor = vec4(finalColor, 1.0 );
	}
</script>