<script id="shader-fs" type="x-shader/x-fragment">
	//http://spidergl.org/example.php?id=6
	highp vec4 pack_depth( const in highp float depth ) {
		const highp vec4 bit_shift = vec4( 256.0 * 256.0 * 256.0, 256.0 * 256.0, 256.0, 1.0 );
		const highp vec4 bit_mask  = vec4( 0.0, 1.0 / 256.0, 1.0 / 256.0, 1.0 / 256.0 );
		highp vec4 res = fract( depth * bit_shift );
		res -= res.xxyz * bit_mask;
		return res;
	}

	//http://www.nutty.ca/?page_id=352&amp;link=shadow_map		
	highp vec4 pack_depth2 (highp float depth)
	{
		const highp vec4 bias = vec4(1.0 / 255.0,
					1.0 / 255.0,
					1.0 / 255.0,
					0.0);

		highp float r = depth;
		highp float g = fract(r * 255.0);
		highp float b = fract(g * 255.0);
		highp float a = fract(b * 255.0);
		highp vec4 colour = vec4(r, g, b, a);
		
		return colour - (colour.yzww * bias);
	}	

	void main()
	{	
	    gl_FragColor = pack_depth( gl_FragCoord.z );
	    //gl_FragColor = pack_depth2( gl_FragCoord.z );
	}
</script>