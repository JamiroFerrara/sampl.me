<script lang="ts">
	export let value = '';
	export let name = '';

	let error = '';
	let has_error = false;
</script>

<label class="label">
	<span>{name}</span>
	<input {name} class={has_error ? 'input input-error' : 'input'} type="text" bind:value />
	<div class="text-red-600">
		{error}
	</div>
</label>
