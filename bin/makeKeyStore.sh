keytool -genkey -v -keystore my-release-key.keystore -alias alias_name -keyalg RSA -keysize 2048 -validity 10000
cat my-release-key.keystore | base64

keytool -genkeypair -v -keystore my-relase.keystore -alias pla -keyalg RSA -keysize 2048 -validity 10000
cat my-relase.keystore | base64
