module.exports = {
  content: [
    "./Pages/**/*.{razor,cshtml}",
    "./Shared/**/*.{razor,cshtml}"
  ],
  darkMode: true,
  theme: {
    extend: {}
  },
  variants: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/typography'),
    require('@tailwindcss/forms'),
  ],
}