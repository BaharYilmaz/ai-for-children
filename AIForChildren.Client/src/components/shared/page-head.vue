<template>
	<h4 class="font-weight-bold py-3 mb-4">
		<b-icon	v-if="icon"	:icon="icon" />	<span class="text-muted font-weight-light">{{ prefix }} / </span> {{ title }}
	</h4>	
</template>

<script>
export default {
	props: {
		title: {
			"default": "title",
			"type" : String
		},
		prefix: {
			"default": "AIForChildren",
			"type" : String
		},
		icon: {
			"type" : String
		}
	}
}
</script>