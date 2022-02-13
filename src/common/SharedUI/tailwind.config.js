module.exports = {
  mode: 'jit',
  content: [ "**/*.razor", "**/*.cshtml", "**/*.html" ],
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