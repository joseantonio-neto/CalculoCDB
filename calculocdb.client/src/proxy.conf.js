const { env } = require('process');

let target = 'https://localhost:7118';
if (env.ASPNETCORE_HTTPS_PORT) {
  target = `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`;
} else if (env.ASPNETCORE_URLS) {
  const urls = env.ASPNETCORE_URLS.split(';');
  target = urls[0];
}

const PROXY_CONFIG = [
  {
    context: [
      "/calculate"
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
