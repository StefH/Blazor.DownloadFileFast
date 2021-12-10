rem https://github.com/StefH/GitHubReleaseNotes

SET version=0.2.0

GitHubReleaseNotes --output ReleaseNotes.md --skip-empty-releases --exclude-labels question invalid doc help-wanted --version %version% --token %GH_TOKEN%