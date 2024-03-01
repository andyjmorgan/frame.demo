const PROXY_CONFIG = [
  {
    context: [
      "/api",
    ],
    target: 'http://frame.demo/',
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    },
    changeOrigin: true
  }
]

module.exports = PROXY_CONFIG;
