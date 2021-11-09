#!/usr/bin/python
# -*- coding: UTF-8 -*-

import os

cwd = os.getcwd()
os.chdir(cwd)
try:
    os.system('git pull')
except Exception as e:
    raise RuntimeError(
        "Failed to git pull from path '{0}' with exception '{1}'".format(cwd, e))
else:
    print('GIT PULL DONE!!!')
