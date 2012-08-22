<?php
error_reporting(E_ALL);
    function formatPostalCode($postal_code)
    {
        $pc = trim($postal_code);
        $pc = str_replace(' ', '', $pc);
        $pc = str_replace('-', '', $pc);
        $pc = substr($pc, 0, 9);
        return $pc;
    }

echo formatPostalCode('A1A A1A').'<br/>';
echo formatPostalCode(' A1A A1A ').'<br/>';
echo formatPostalCode(' A1A        A1A ').'<br/>';
echo formatPostalCode('90210').'<br/>';
echo formatPostalCode(null).'<br/>';
echo formatPostalCode('79721-0608').'<br/>';
