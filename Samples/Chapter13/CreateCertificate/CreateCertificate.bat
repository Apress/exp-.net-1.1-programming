MakeCert -sv TestRoot.pvk -r -n "CN=Simons Test Root" TestRoot.cer 
Cert2SPC TestRoot.cer TestRoot.spc 
CertMgr -add -c TestRoot.cer -s root

