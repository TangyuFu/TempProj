#!/usr/bin/python
# -*- coding: UTF-8 -*-

import sys
import os

scriptname = str(sys.argv[0])
untiypath = str(sys.argv[1])
logpath = str(sys.argv[2])
projectpath = str(sys.argv[3])
executemethod = str(sys.argv[4])

command = '{0} -quit -batchmode -logFile {1} -projectPath {2} -executeMethod {3}'.format(untiypath, logpath, projectpath, executemethod)

os.system(command)