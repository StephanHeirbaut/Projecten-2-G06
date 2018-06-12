#!/bin/bash

#variabelen instellen
user='vagrant'
password='vagrant'
databaseName='testapp'
mysqlRootPass='TestApp95'

#install tomcat server
yum install -y tomcat

#grafische interface voor tomcat
yum install tomcat-webapps tomcat-admin-webapps

#install mariadb
yum install -y mariadb-server

#install JAVA (OpenJDK)
yum install java-1.8.0-openjdk java-1.8.0-openjdk-devel maven

#start tomcat server
systemctl start tomcat

#start tomcat daemon
systemctl enable tomcat

#start mariadb
systemctl enable mariadb

#enable startup mariadb
systemctl start mariadb

#restart tomcat service
systemctl restart tomcat

#install mysql_secure_installation als er nog geen rootwachtwoord is ingesteld 
#er wordt een database aangemaakt en een mysqluser met wachtwoord voor de testapplicatie.
if mysqladmin -u root status > /dev/null 2>&1; then
  mysqladmin password "${mysqlRootPass}" > /dev/null 2>&1
  mysql --user=root --password=${mysqlRootPass} <<_EOF_
  DELETE FROM mysql.user WHERE User='';
  DELETE FROM mysql.user WHERE User='root' AND Host NOT IN ('localhost', '127.0.0.1', '::1');
  DROP DATABASE IF EXISTS test;
  DELETE FROM mysql.db WHERE Db='test' OR Db='test\\_%';
  CREATE DATABASE if not exists $databaseName;
  GRANT all privileges ON $databaseName.* TO '$user'@'localhost' identified by '$password';
  FLUSH PRIVILEGES;
_EOF_
else
  echo "het wachtwoord is al ingesteld"
fi

#firewall configuration
systemctl start firewalld.service
firewall-cmd --permanent --add-service=mysql
firewall-cmd --permanent --add-service=ssh
firewall-cmd --permanent --add-port=8080/tcp
firewall-cmd --reload