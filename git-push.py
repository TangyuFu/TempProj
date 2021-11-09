#!/usr/bin/python
# -*- coding: UTF-8 -*-

import sys
import os

# init commit comment.
comment = None
if len(sys.argv) > 1:
    comment = ' '.join(sys.argv[1:])
if not comment:
    comment = "unspecified commit comment."
# call git commands.
try:
    cwd = os.getcwd()
    os.chdir(cwd)
    os.system('git pull')
    os.system('git status')
    os.system('git add .')
    os.system('git commit -m "{0}"'.format(comment))
    os.system('git push')
except Exception as e:
    raise RuntimeError(
        "Failed to git push from path '{0}' with exception '{1}'".format(cwd, e))
else:
    print('GIT PUSH DONE!!!')
