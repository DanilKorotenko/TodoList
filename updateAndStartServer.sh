#!/bin/bash

cd /home/danil_korotenko/TodoList/

git pull;

cd WebToDoList/todolistweb

npm run build

cd ../../nodejsServer;

npm run startPort80;
