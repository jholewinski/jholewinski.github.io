#!/usr/bin/env python
# -*- coding: utf-8 -*- #
from __future__ import unicode_literals

#PLUGIN_PATH = 'pelican-plugins'
#PLUGINS = [ 'latex' ]

AUTHOR = u'Justin Holewinski'
SITENAME = u'Justin\'s Code Haus'
SITEURL = 'http://localhost:8000'
SITESUBTITLE = u'Ramblings of a compiler engineer'

TIMEZONE = 'US/Eastern'

DEFAULT_LANG = u'en'

DELETE_OUTPUT_DIRECTORY = True

# Feed generation is usually not desired when developing
FEED_ALL_ATOM = None
CATEGORY_FEED_ATOM = None
TRANSLATION_FEED_ATOM = None

# Blogroll
#LINKS =  (('Pelican', 'http://getpelican.com/'),
#          ('Python.org', 'http://python.org/'),
#          ('Jinja2', 'http://jinja.pocoo.org/'),
#          ('You can modify those links in your config file', '#'),)

# Social widget
#SOCIAL = (('You can add links in your config file', '#'),
#          ('Another social link', '#'),)


#LINKS = (('Foo', 'bar'))
#SOCIAL = (('Foo', 'bar'))

LINKS = (('GitHub', 'http://github.com/jholewinski'),)
SOCIAL = ()

SUMMARY_MAX_LENGTH = 0
DEFAULT_PAGINATION = 5

# Uncomment following line if you want document-relative URLs when developing
#RELATIVE_URLS = True

ARTICLE_URL = '{slug}/index.html'
ARTICLE_SAVE_AS = ARTICLE_URL
PAGE_URL = '{slug}/index.html'
PAGE_SAVE_AS = PAGE_URL

DISQUS_SITENAME = 'justinscodehaus'

STATIC_PATHS = [ 'images', ]

TAG_CLOUD_STEPS = 1
#PDF_GENERATOR = True

#MONTH_ARCHIVE_SAVE_AS = 'blog/{date:%Y}/{date:%b}/index.html'

#THEME = 'notmyidea'
#THEME = 'pelican-themes/pelican-cait'
#THEME = 'pelican-themes/relapse'
THEME = 'relapse-mod'

"""
Just-Read/
README.rst
basic/
bluegrasshopper/
bold/
bootlex/
bootstrap/
bootstrap2/
brownstone/
built-texts/
cebong/
chunk/
dev-random/
dev-random2/
fresh/
irfan/
iris/
lannisport/
lightweight/
martyalchin/
mnmlist/
neat/
nmnlist/
notmyidea-cms/
notmyidea-cms-fr/
pelican-cait/
pelican-mockingbird/
relapse/
sneakyidea/
subtle/
svbtle/
syte/
tuxlite_tbs/
tuxlite_zf/
water-iris/
waterspill/
waterspill-en/
"""
