set JAVA_HOME=c:\j2sdk1.4.2_10
cd \Random.dteSIERRALTA
%JAVA_HOME%\bin\java -classpath .;lib\bcprov-jdk14-133.jar;lib\log4j-1.2.8.jar;lib\commons-logging.jar;lib\iaik_jce_full.jar;lib\jtds-1.2.jar;lib\PDF417BarcodeLib.jar;lib\xmlsec-1.3.0.jar;lib\dte1.0.0.jar;lib\dtebin1.0.0.jar  GetRut %1
