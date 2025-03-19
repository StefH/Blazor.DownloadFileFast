rem https://github.com/StefH/GitHubReleaseNotes

SET version=1.0.0-preview-03

GitHubReleaseNotes --output ReleaseNotes.md --skip-empty-releases --exclude-labels question invalid doc help-wanted --version %version% --token %GH_TOKEN%