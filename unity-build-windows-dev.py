#!/usr/bin/python
# -*- coding: UTF-8 -*-

import sys
import os
import time

scriptname = str(sys.argv[0])
untiypath = 'C:/progra~1/Unity/Hub/Editor/2020.3.0f1/Editor/Unity.exe'
projectpath = 'D:/UnityGameFramework/'
logpath = '{0}{1}.txt'.format(projectpath, time.strftime("%Y.%m.%d-%H.%M.%S", time.localtime()))
executemethod = 'UnityGameFramework.Editor.Extension.Build.BuildController.BuildWindowsDevelopment'

command = 'python {0} {1} {2} {3} {4}'.format('unity-build.py', untiypath, logpath, projectpath, executemethod)

os.system(command)