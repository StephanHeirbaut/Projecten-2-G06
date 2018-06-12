#!/bin/bash

user='vagrant'
password='vagrant'
databaseName='testapp'
mysqlRootPass='TestApp95'

#install apache server
yum install -y httpd

#install mariadb
yum install -y mariadb-server

#enable startup mariadb
systemctl start mariadb

#install mysql_secure_installation
if mysqladmin -u root status > /dev/null 2>&1; then
  mysqladmin password "${mysqlRootPass}" > /dev/null 2>&1
  #UPDATE mysql.user SET Password=PASSWORD('$mysqlRootPass') WHERE User='root';
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

#install php
yum install -y php php-mysql php-gd php-ldap php-odbc php-pear php-xml php-xmlrpc php-mbstring php-snmp php-soap

#start apache server
systemctl start httpd 

#start apache daemon
apachectl start

#start mariadb
systemctl enable mariadb

#restart service
systemctl restart httpd.service

#firewall configuration
systemctl start firewalld.service
firewall-cmd --permanent --add-service=mysql
firewall-cmd --permanent --add-service=ssh
firewall-cmd --permanent --zone=public --add-service=http 
firewall-cmd --permanent --zone=public --add-service=https
firewall-cmd --reload